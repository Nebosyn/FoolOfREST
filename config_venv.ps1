python -m pip install virtualenv
python -m virtualenv .\FoolOfRESTAPI\TelegramLogger\.venv
$DirsInsideVenv = Get-ChildItem .\FoolOfRESTAPI\TelegramLogger\.venv
if ($DirsInsideVenv -match "Scripts"){
	.\FoolOfRESTAPI\TelegramLogger\.venv\Scripts\activate.ps1
}
elseif ($DirsInsideVenv -match "bin"){
	.\FoolOfRESTAPI\TelegramLogger\.venv\bin\activate.ps1
}
else{
	Write-Error "Error occured"
	Return
}
python -m pip install -r .\FoolOfRESTAPI\TelegramLogger\requirements.txt