from telegram import Message
from datetime import timezone
from psycopg2.extensions import connection

def writeMessage(conn: connection, message: Message):
    user = message.from_user    
    if user == None:
        return
    chat = message.chat
    if chat == None:
        return
    cursor = conn.cursor()
    cursor.execute(f"SELECT id FROM users WHERE id='{user.id}'")
    if cursor.fetchone() == None:
        cursor.execute(f"INSERT INTO users VALUES ('{user.id}','{user.name}');")
    cursor.execute(f"SELECT id FROM chats WHERE id='{chat.id}'")
    if cursor.fetchone() == None:
        cursor.execute(f"INSERT INTO chats VALUES ({chat.id}, {chat.title})")
    cursor.execute(f"INSERT INTO messages ('id', 'text', 'date', 'userid', 'chatid')\
                   VALUES ('{message.id}','{message.text}', '{message.date.now(timezone.utc).strftime("%Y-%m-%d %H:%M:%S%z")}', '{user.id}', '{chat.id}');")
    conn.commit()
