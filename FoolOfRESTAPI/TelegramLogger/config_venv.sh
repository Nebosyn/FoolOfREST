#!/bin/bash
python -m venv .venv
if [[ $? -ne 0 ]]; then
    echo "Something wrong with the python executable, make sure it's installed on the system and added to the path;"
    return 
fi
source .venv/bin/activate
pip install -r requirements.txt
if [[ $? -ne 0 ]]; then
    echo "Probably there is no requirements.txt file for python to use, please make sure it's in the current working directory."
    return 
fi

echo ""
echo "Venv was successfully created and all packages were downloaded."
