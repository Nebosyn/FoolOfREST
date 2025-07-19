import os
import telegram.ext
from telegram.ext import ApplicationBuilder, MessageHandler, filters

import Handlers
import psycopg

class Logger():
    app: telegram.ext.Application

    def __init__(self) -> None:
        TOKEN = os.getenv("TOKEN")
        if TOKEN == None:
            exit("No TOKEN were provided in .env.")

        self.app = ApplicationBuilder().token(TOKEN).build()

        self.__init_handlers()
        self.__init_database()
        print("\033[1;32mTelegram Bot successfully initiated.")
        print("Logging started...\033[0m")
        
    def __init_handlers(self) -> None:
        self.app.add_handler(MessageHandler(filters.TEXT, Handlers.message_sent)) 
        self.app.add_error_handler(Handlers.error_handler)  # pyright: ignore[reportArgumentType]

    def __init_database(self) -> None:
        CONNECTION_STRING = os.getenv("CONNECTION_STRING")
        if CONNECTION_STRING == None:
            exit("No CONNECTION_STRING were provided in .env.")
        conn = psycopg.connect(CONNECTION_STRING)
        self.app.bot_data["database"] = conn
