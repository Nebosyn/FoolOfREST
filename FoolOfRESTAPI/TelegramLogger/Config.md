# Python logger configuration
## Python version
For this project please use python version from 3.10 to 3.13. Psycopg3 library used in this repository, isn't supported by python 3.14.
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
or if using **Windows** source via ```activate.bat``` script inside powershell terminal:
> [!NOTE]
> 
> Before running the script you need to change execution policy of your powershell terminal, you can do this with this command:
>```Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope Process -Force```

```console
> .\.venv\Scripts\activate.ps1
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
> [!NOTE]
> 
> Before running the script you need to change execution policy of your powershell terminal, you can do this with this command:
>```Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope Process -Force```

**```config_venv.ps1```**
## Configuring python's environment table.
Before launching the program you need to:
- Create .env file inside the directory of the python script(```FoolOfRestAPI/TelegramLogger/.env```)
- Add your personal telegram bot ```TOKEN``` and Postgres ```CONNECTION_STRING``` to it:

```py
#FoolOfRestAPI/TelegramLogger/.env
TOKEN = "<YOUR_TELEGRAM_BOT_TOKEN>"
CONNECTION_STRING = "<POSTGRES_CONFIGURATION_STRING>"
```

### Telegram Bot ```TOKEN```
To create your own telegram bot TOKEN, use [@BotFather](https://telegram.me/BotFather) in Telegram.

### Postgres ```CONNECTION_STRING```
> [!WARNING]
>
> Please note that variables in the configuration string should be written in lowercase:
>#### ``` CONNECTION_STRING = "host=localhost port=5432 dbname=Database user=username"```

Variables differences in **dotConnect(ADO.NET)** and **.env** ```CONNECTION_STRING```:
| ADO.NET | .env |
|------|----------|
|**host**|**host**|
|**port**|**port**|
| **database**| **dbname**|
|**username** | **user** |

More on [Postgres connection string variables](https://www.postgresql.org/docs/current/libpq-connect.html#LIBPQ-PARAMKEYWORDS).
