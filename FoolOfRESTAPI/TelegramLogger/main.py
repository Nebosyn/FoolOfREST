import logging

from dotenv import load_dotenv

from Bot import Logger

def main():
    bot = Logger()
    bot.app.run_polling()

if __name__ == "__main__":
    #logging.basicConfig(format="%(asctime)s - %(name)s - %(message)s",
    #                    level=logging.INFO)
    load_dotenv()
    main()
