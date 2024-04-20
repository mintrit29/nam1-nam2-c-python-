with open('data.txt','r') as file:#read data file
    #content = file.read()#bytes read from file
    '''line1 = file.readline()
    line2 = file.readline()'''
    lines = file.readlines()
    print(lines)
for line in lines:
    print(line.strip())