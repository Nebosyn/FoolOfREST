from datetime import timezone
from psycopg2.extensions import connection
from telegram import Update
from telegram.ext import ContextTypes

async def message_sent(update: Update, context: ContextTypes.DEFAULT_TYPE):
    message = update.message
    if message == None:
        return
    user = message.from_user    
    if user == None:
        return
    print(f"New message: username={user.name} -- message={message.text}")
    print("Wrote data to sql database.")
    conn:connection = context.bot_data["database"]
    cursor = conn.cursor()

    cursor.execute(f"SELECT id FROM users WHERE id='{user.id}'")
    if cursor.fetchone() != None:
        print("Id Already exists")
    else:
        cursor.execute(f"INSERT INTO users VALUES ('{user.id}','{user.name}');")
    cursor.execute(f"INSERT INTO messages VALUES ('{message.id}','{message.text}', '{message.date.now(timezone.utc).strftime("%Y-%m-%d %H:%M:%S%z")}', '{user.id}');")
    conn.commit()
