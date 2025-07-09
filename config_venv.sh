#!/bin/bash
python -m venv ./FoolOfRESTAPI/TelegramLogger/.venv
if [[ $? -ne 0 ]]; then
    echo "Something wrong with the python executable, make sure it's installed on the system and added to the path;"
    return 
fi
source ./FoolOfRESTAPI/TelegramLogger/.venv/bin/activate
pip install -r ./FoolOfRESTAPI/TelegramLogger/requirements.txt
if [[ $? -ne 0 ]]; then
    echo "Installation failed, please make sure you're using python version 3.12 or 3.13"
    return 
fi

echo ""
echo "Venv was successfully created and all packages were downloaded."
