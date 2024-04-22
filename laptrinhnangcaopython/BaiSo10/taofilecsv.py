import csv
with('employee_file.csv',mode='w') as employee_file:
    employee_writer = csv.writer(employee_file,delimiter=',',)