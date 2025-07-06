import Database
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
    Database.writeMessage(conn, message)
