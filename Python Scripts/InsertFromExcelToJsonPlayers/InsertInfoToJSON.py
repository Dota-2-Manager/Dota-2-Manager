import openpyxl
import json

from datetime import date
from openpyxl import load_workbook

#README
#This is still ín testing, there may exist bug I didn't find
#For age make sure that all dates you get from the excel sheet are in real date format and not strings

#How to use:
#1. Download the spreadsheet with the info
#2. Put it in the same folder as this script
#3. Run the script
#4. ???
#5. Done


sheets = []
players = []
pl2 = []

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
    pl2.append([])

f = open('playersInfo1.json', 'w')
#Adds every player to hiw own row in a list
for i in range(0, len(sheets)):
    sheet = wb.get_sheet_by_name(sheets[i])
    players[i].append(sheet['B2'].value)
    players[i].append(sheet['B3'].value)
    players[i].append(sheet['F2'].value)
    players[i].append(sheet['F3'].value)

    players[i].append(sheet['F7'].value)
    players[i].append(sheet['F8'].value)
    players[i].append(sheet['F9'].value)

    players[i].append(sheet['B7'].value) 
    players[i].append(sheet['B8'].value)
    players[i].append(sheet['B9'].value)
    players[i].append(sheet['B10'].value)

    players[i].append(sheet['D7'].value)
    players[i].append(sheet['D8'].value)
    players[i].append(sheet['D9'].value)
    players[i].append(sheet['D10'].value)
    players[i].append(sheet['D11'].value)

    players[i].append(sheet['B14'].value)
    players[i].append(sheet['B15'].value)
    players[i].append(sheet['B16'].value)
    players[i].append(sheet['B17'].value) 
    players[i].append(sheet['B18'].value)

    players[i].append(sheet['D14'].value)
    players[i].append(sheet['D15'].value)
    players[i].append(sheet['D16'].value) 
    players[i].append(sheet['D17'].value)
    players[i].append(sheet['D18'].value)

    try:
        players[i][2] = date.isoformat(players[i][2])
    except TypeError:
        #print(players[i][0])
        #print(players[i][2])
        #print("---------")
        pass

    #Dumps the whole data to the json file
    pl2[i] = {'Name': players[i][0], 
    'Country': players[i][1], 
    'BirthDate': players[i][2],
    'Team': players[i][3], 
    'Stats':{
    'Happiness': players[i][4],
    'Greed': players[i][5],
    'CurrentRole': players[i][6],
    'Pushing': players[i][7],
    'Farming': players[i][8],
    'Fighting': players[i][9],
    'Warding': players[i][10],
    'Positioning': players[i][11],
    'MapAwareness': players[i][12],
    'DecisionMaking': players[i][13],
    'Roaming': players[i][14],
    'LaneControl': players[i][15],
    'RiskTaking': players[i][16],
    'Flair': players[i][17],
    'Consistency': players[i][18],
    'TeamWork': players[i][19],
    'Leadership': players[i][20]
    }, 
    'PositionPreference':{
    'Poistion_1': players[i][21],
    'Poistion_2': players[i][22],
    'Poistion_3': players[i][23],
    'Poistion_4': players[i][24],
    'Poistion_5': players[i][25]
    }}
json.dump({'players': pl2}, f, indent=4)







f.closed