# Python logger configuration
## Python version
For this project please use python version 3.12 or 3.13. Psycopg2 library used in this repository, isn't supported by python 3.14.
## Configuring python's virtual environment

### Manually
To configure virtual environment we essentially need only several commands. 

First we'll need to create venv:
```console
$ python -m venv .venv
```
then source into it via activation file inside ```/.venv/bin/activate```:
```console
$ source .venv/bin/activate
```
or if using **Windows** source via ```activate.bat``` script:
```console
> .\.venv\bin\activate.bat
```
Lastly we'll install python required packages:
``` console
$ pip install -r requirements.txt
```
### Using script 
> [!NOTE]
>
> Please make sure that python is installed and added to PATH environment table on your system before executing installation script.
- ### Linux
**```config_venv.sh```**
- ### Windows
**```config_venv.ps1```**
## Configuring python's environment table.
Before launching the program you need to write two variables in .env file in the directory of the python script:
```py
#FoolOfRestAPI/TelegramLogger/.env
TOKEN = "<YOUR_TELEGRAM_BOT_TOKEN>"
CONNECTION_STRING = "<POSTGRES_CONFIGURATION_STRING>"
```
> [!WARNING]
>
> Please note that variables in the configuration string should be written in lowercase.
>**CONNECTION_STRING** example:
>
>``` CONNECTION_STRING = "host=localhost port=5432 dbname=Database user=username"```

To create your own telegram bot TOKEN, use [@BotFather](https://telegram.me/BotFather) bot in telegram.
