import openpyxl
import json

from datetime import date
from openpyxl import load_workbook

#README
#This is still ín testing, there may exist bug I didn't find
#For age make sure that all dates you get from the excel sheet are in real date format and not strings or that hey are N/A

#How to use:
#1. Download the spreadsheet with the info
#2. Put it in the same folder as this script
#3. Run the script
#4. ???
#5. Done


sheets = []
players = []
ages = []

#Loads the whole excel file
wb = load_workbook('Attribute Sheet.xlsx')

#Gets the sheets names and puts it in a list
sheets = wb.get_sheet_names()
#Removes some templates to not break when parsing
i = 0
b = len(sheets)
while (i < b):
    if(sheets[i] == "Sheet1" or sheets[i] == "Sheet2" or sheets[i] == "Player" or sheets[i] == "Team Attributes"):
        del sheets[i]
        b = len(sheets)
        continue
    i += 1

#Fills every player list with 1 empty info so that they can have their own row
for i in range(0, len(sheets)):
    players.append([])

f = open('playersInfo.json', 'w')

#Adds every player to his own ron in the json input
for i in range(0, len(sheets)):
    sheet = wb.get_sheet_by_name(sheets[i])
    ages.append(sheet['F2'].value)

    try:
        ages[i] = date.isoformat(ages[i])
    except TypeError:
        pass

    #Dumps the whole data to the json file
    players[i] = {'Name': sheet['B2'].value, 
    'Country': sheet['B3'].value, 
    'BirthDate': ages[i],
    'Team': sheet['F3'].value, 
    'Stats':{
    'Happiness': sheet['F7'].value,
    'Greed': sheet['F8'].value,
    'CurrentRole': sheet['F9'].value,
    'Pushing': sheet['B7'].value,
    'Farming': sheet['B8'].value,
    'Fighting': sheet['B8'].value,
    'Warding': sheet['B10'].value,
    'Positioning': sheet['D7'].value,
    'MapAwareness': sheet['D8'].value,
    'DecisionMaking': sheet['D9'].value,
    'Roaming': sheet['D10'].value,
    'LaneControl': sheet['D11'].value,
    'RiskTaking': sheet['B14'].value,
    'Flair': sheet['B15'].value,
    'Consistency': sheet['B16'].value,
    'TeamWork': sheet['B17'].value,
    'Leadership': sheet['B18'].value
    }, 
    'PositionPreference':{
    'Poistion_1': sheet['D14'].value,
    'Poistion_2': sheet['D15'].value,
    'Poistion_3': sheet['D16'].value,
    'Poistion_4': sheet['D17'].value,
    'Poistion_5': sheet['D18'].value
    }}
json.dump({'players': players}, f, indent=4)

f.closed