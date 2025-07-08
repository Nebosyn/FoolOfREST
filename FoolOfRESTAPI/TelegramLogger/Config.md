# Python logger configuration
## Configuring python virtual environment
> [!NOTE]
>
> Please make sure that python is installed and added to PATH environment table on your system before executing installation script.

### Manual configuration
To configure virtual environment we essentially need only to commands. 

First we'll need too create venv:
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
### Script configuration 
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
> Please note that variables in the configuration string should be written in lowcase.
>**CONNECTION_STRING** example:
>
>``` CONNECTION_STRING = "host=localhost port=5432 dbname=Database user=username"```

To create your own telegram bot TOKEN, use [@BotFather](https://telegram.me/BotFather) bot in telegram.
