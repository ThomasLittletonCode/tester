import csv
import gspread

MONTH = 'may'
file = f"scu_{MONTH}.csv"

def scu(file):
    with open(file, mode='r') as csvfile:
        csv_reader = csv.reader(csvfile)
        rows = [row for row in csv_reader]
    return rows

sa = gspread.service_account()
sh = sa.open("Untitled spreadsheet")

# Use the value of MONTH variable in the worksheet name
wks = sh.worksheet(MONTH)

# Call the scu function to get rows
rows = scu(file)

# Correct the method name to insert_row
wks.insert_row([1, 2, 3], 10)
