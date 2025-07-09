from telegram import Message
from datetime import timezone
from psycopg import Connection, sql 

def writeMessage(conn: Connection, message: Message):
    user = message.from_user    
    if user == None:
        return
    chat = message.chat
    if chat == None:
        return
    cursor = conn.cursor()
    cursor.execute(f"SELECT id FROM users WHERE id=%s", (user.id,))
    if cursor.fetchone() == None:
        cursor.execute(f"INSERT INTO users VALUES (%s, %s);", (user.id,user.name))
    cursor.execute(sql.SQL("SELECT id FROM chats WHERE id='{}'").format(user.id))
    if cursor.fetchone()== None:
        if int(chat.id) > 0:
            cursor.execute(f"INSERT INTO chats VALUES (%s, %s)", (chat.id, f"PRIVATE:{chat.id}"))
        else:
            cursor.execute(f"INSERT INTO chats VALUES (%s, %s)", (chat.id, chat.title))
    cursor.execute(f"INSERT INTO messages (id, text, date, userid, chatid) VALUES (%s, %s, %s, %s, %s);", 
                   (message.id,message.text, message.date.now(timezone.utc).strftime("%Y-%m-%d %H:%M:%S%z"), user.id, chat.id))
    conn.commit()
