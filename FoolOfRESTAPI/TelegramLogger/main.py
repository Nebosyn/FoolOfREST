import os
from dotenv import load_dotenv

from Bot import Logger

def main():
    bot = Logger()
    bot.app.run_polling()

if __name__ == "__main__":
    load_dotenv(os.path.join(os.path.curdir, ".env"))
    main()
