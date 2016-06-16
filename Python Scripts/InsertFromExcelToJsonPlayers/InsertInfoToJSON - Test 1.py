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
        print(players[i][0])
        print(players[i][2])
        print("---------")
        pass
    
#print(players[10])
#exit()
#for i in range(0, len(players)):
#print(players[i][24])
#print(date.isoformat(players[10][2]))



"""
# Dump every player to their own array without any names
f = open('playersInfo.json', 'w')

#print(json.dumps(players[0]))

json.dump(players[0], f)
json.dump(players[1], f)

f.closed
"""

f = open('playersInfo.json', 'w')

f.write('{"players":[\n')

#Writes line by line every stat for each player

#for i in range(10, 13):
for i in range(10, len(players)):
    f.write('\t{\n')
    f.write('\t\t"Name": "'+players[i][0]+'",\n')
    f.write('\t\t"Country": "'+players[i][1]+'",\n')
    f.write('\t\t"Age": "'+players[i][2]+'",\n')
    f.write('\t\t"Team": "'+players[i][3]+'",\n')
    f.write('\t\t"Stats": {\n')
    f.write('\t\t\t"Happiness": '+str(players[i][4])+',\n')
    f.write('\t\t\t"Greed": '+str(players[i][5])+',\n')
    f.write('\t\t\t"CurrentRole": "'+str(players[i][6])+'",\n')
    f.write('\t\t\t"Pushing": '+str(players[i][7])+',\n')
    f.write('\t\t\t"Farming": '+str(players[i][8])+',\n')
    f.write('\t\t\t"Fighting": '+str(players[i][9])+',\n')
    f.write('\t\t\t"Warding": '+str(players[i][10])+',\n')
    f.write('\t\t\t"Positioning": '+str(players[i][11])+',\n')
    f.write('\t\t\t"MapAwareness": '+str(players[i][12])+',\n')
    f.write('\t\t\t"DecisionMakeing": '+str(players[i][13])+',\n')
    f.write('\t\t\t"Roaming": '+str(players[i][14])+',\n')
    f.write('\t\t\t"LaneControl": '+str(players[i][15])+',\n')
    f.write('\t\t\t"RiskTakeing": '+str(players[i][16])+',\n')
    f.write('\t\t\t"Flair": '+str(players[i][17])+',\n')
    f.write('\t\t\t"Consistency": '+str(players[i][18])+',\n')
    f.write('\t\t\t"TeamWork": '+str(players[i][19])+',\n')
    f.write('\t\t\t"Leadership": '+str(players[i][20])+'\n')
    f.write('\t\t},\n')
    f.write('\t\t"PositionPreference": {\n')
    f.write('\t\t\t"Position_1": '+str(players[i][21])+',\n')
    f.write('\t\t\t"Position_2": '+str(players[i][22])+',\n')
    f.write('\t\t\t"Position_3": '+str(players[i][23])+',\n')
    f.write('\t\t\t"Position_4": '+str(players[i][24])+',\n')
    f.write('\t\t\t"Position_5": '+str(players[i][25])+'\n')
    f.write('\t\t}\n')

    if(i == (len(players) - 1)):
        f.write('\t}\n')    
    else:
        f.write('\t},\n')

f.write(']\n')
f.write('}\n')

f.closed