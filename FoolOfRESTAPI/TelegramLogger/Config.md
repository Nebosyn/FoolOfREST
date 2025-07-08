# Python logger configuration
Before launching the program you need to write two variables in .env file in the directory of the python script:
```py
#FoolOfRestAPI/TelegramLogger/.env
TOKEN = "<YOUR_TELEGRAM_BOT_TOKEN>"
CONNECTION_STRING = "<POSTGRES_CONFIGURATION_STRING>"
```
> [!WARNING]
>
> Please note that variables in the configuration string should be written in lowcase.
>**CONNECTION_STRING** example:
>
>``` CONNECTION_STRING = "host=localhost port=5432 dbname=Database user=username"```

To create your own telegram bot TOKEN, use [@BotFather](https://telegram.me/BotFather) bot in telegram.
