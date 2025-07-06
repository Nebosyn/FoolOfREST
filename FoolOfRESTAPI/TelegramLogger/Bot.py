import os
import telegram.ext
from telegram.ext import ApplicationBuilder, MessageHandler, filters

import Handlers
import psycopg2

class Logger():
    app: telegram.ext.Application

    def __init__(self):
        TOKEN = os.getenv("TOKEN")
        if TOKEN == None:
            exit("No TOKEN were provided in .env.")

        self.app = ApplicationBuilder().token(TOKEN).build()

        self.__init_handlers()
        self.__init_database()
        
    def __init_handlers(self):
        self.app.add_handler(MessageHandler(filters.TEXT, Handlers.message_sent)) 

    def __init_database(self):
        CONNECTION_STRING = os.getenv("CONNECTION_STRING")
        if CONNECTION_STRING == None:
            exit("No CONNECTION_STRING were provided in .env.")
        conn = psycopg2.connect(CONNECTION_STRING)
        self.app.bot_data["database"] = conn
