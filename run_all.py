import os
import sys
import subprocess
import time
import sqlite3
from pathlib import Path

# ============ 配置 ============
PROJECT_ROOT = Path(__file__).parent.resolve()
BACKEND_DIR = PROJECT_ROOT / "Backend"
FRONTEND_DIR = PROJECT_ROOT / "Frontend"
DB_PATH = BACKEND_DIR / "app.db"
INIT_SQL_PATH = BACKEND_DIR / "Database" / "sql" / "init.sql"
INIT_FLAG = BACKEND_DIR / ".db_initialized"  # 标记文件，避免重复初始化

DOTNET = "dotnet"  # 确保 dotnet 在 PATH 中

# ============ 辅助函数 ============
def run_cmd(cmd, cwd, **kwargs):
    print(f"[RUN] in {cwd}: {' '.join(cmd)}")
    return subprocess.Popen(cmd, cwd=cwd, **kwargs)

def execute_sql_script(db_path, sql_path):
    """执行 SQL 脚本（支持多条语句）"""
    with open(sql_path, "r", encoding="utf-8") as f:
        sql = f.read()
    conn = sqlite3.connect(db_path)
    conn.executescript(sql)
    conn.commit()
    conn.close()
    print(f"[DB] Executed init script: {sql_path}")

# ============ 主流程 ============
if __name__ == "__main__":
    # 1. 检查 init.sql 是否存在
    if not INIT_SQL_PATH.exists():
        print(f"[ERROR] init.sql not found at {INIT_SQL_PATH}")
        sys.exit(1)

    # 2. 启动后端（非阻塞）
    backend_proc = run_cmd([DOTNET, "run"], cwd=BACKEND_DIR)

    # 3. 等待数据库文件出现（最多 10 秒）
    print("[WAIT] Waiting for app.db to be created by backend...")
    for _ in range(20):
        if DB_PATH.exists():
            break
        time.sleep(0.5)
    else:
        print("[ERROR] Timeout waiting for app.db")
        backend_proc.terminate()
        sys.exit(1)

    # 4. 如果未初始化过，执行 init.sql
    if not INIT_FLAG.exists():
        print("[DB] Initializing data...")
        try:
            execute_sql_script(DB_PATH, INIT_SQL_PATH)
            INIT_FLAG.write_text("initialized at " + time.ctime())
            print("[DB] Initialization complete.")
        except Exception as e:
            print(f"[ERROR] Failed to initialize DB: {e}")
    else:
        print("[DB] Already initialized, skip init.sql")

    # 5. 启动前端
    frontend_proc = run_cmd([DOTNET, "run"], cwd=FRONTEND_DIR)

    # 6. 等待任一进程退出（或手动 Ctrl+C）
    try:
        backend_proc.wait()
        frontend_proc.wait()
    except KeyboardInterrupt:
        print("\n[STOP] Terminating...")
        backend_proc.terminate()
        frontend_proc.terminate()
        backend_proc.wait()
        frontend_proc.wait()
