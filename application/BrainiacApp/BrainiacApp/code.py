# Importing a package
import mne
import numpy as np
import os
import pandas as pd
import sys


"""
read txt file and write it csv file in a convenient format
convenient format:
0,1,2,....,n
3001,3002,.....4000
3001,3002,.....4000
3001,3002,.....4000
3001,3002,.....4000

file type should be csv
file contents:
first line:
    numbers separated by commas should be written starting from zero to the 
    total number of data 
second line:
    data from the first channel should be written here separated by commas
third line:
    data from the second channel should be written here separated by commas
fourth line:
    data from the third channel should be written here separated by commas
fifth line:
    data from the fourth channel should be written here separated by commas
"""

filename = sys.argv[1]
file1 = open(filename, 'r')
count = 0 #total number of data

ch1 = np.array([])
ch2 = np.array([])
ch3 = np.array([])
ch4 = np.array([])

while True:
    
    line = file1.readline()
 
    # if line is empty EOF is reached
    if not line:
        break
    if(line!='\n'): #skip the just empty line from file.
        #get the number of ';'
        result = len(line.split(';'))        
        #if there are 4 ';' then split otherwise skip the line.
        if(result==5):
            a,b,c,d,e=line.split(";")  
            #a-> test number, b->1. data, c-> 2. data, d-> 3. data, e-> 4. data
            count += 1
            ch1 = np.append(ch1,b )
            ch2 = np.append(ch2,c )
            ch3 = np.append(ch3,d )
            e=e.replace('\n','')
            ch4 = np.append(ch4,e )


file1.close()
num = np.array([])
num = np.arange(count) #this is for the first line for csv.

toCsv=open('results-mne.csv','w')
flag = 0
ch1_index=0
ch2_index=0
ch3_index=0
ch4_index=0

#writing to csv file
for j in range(count*5):
    if(count>j):
        if(j==0):
            toCsv.write(str(num[j]))
        else:
            toCsv.write(" ")
            toCsv.write(str(num[j]))        
        
        if(j+1!=(count)):
            toCsv.write(',')
        
    if(j>=count and (count*2)>j):
        if(j==count):
            toCsv.write('\n')  
        toCsv.write(str(ch1[ch1_index]))
        ch1_index+=1
        if(j+1!=(count*2)):
            toCsv.write(',')      
    if(j>=(count*2) and (count*3)>j):
        if(j==(count*2)):
            toCsv.write('\n')  
        toCsv.write(str(ch2[ch2_index]))
        ch2_index+=1
        if(j+1!=(count*3)):
            toCsv.write(',')   
    if(j>=(count*3) and (count*4)>j):
        if(j==(count*3)):
            toCsv.write('\n')  
        toCsv.write(str(ch3[ch3_index]))
        ch3_index+=1
        if(j+1!=(count*4)):
            toCsv.write(',') 
    if(j>=(count*4) and (count*5)>j):
        if(j==(count*4)):
            toCsv.write('\n')  
        toCsv.write(str(ch4[ch4_index]))
        ch4_index+=1
        if(j+1!=(count*5)):
            toCsv.write(',') 


toCsv.write('\n')         
toCsv.close()

data_df=pd.read_csv('results-mne.csv')
#print(data_df.to_string())

data = data_df.to_numpy()
#print(data)

ch_names = ['S1_D1 fnirs', 'S1_D2 fnirs', 'S2_D3 fnirs', 'S2_D4 fnirs'] #channel names
ch_types = ['hbo', 'hbr', 'hbo', 'hbr'] #channel types

sfreq=4.0 #in Hz.

info = mne.create_info(ch_names=ch_names, ch_types=ch_types, sfreq=sfreq)
raw_intensity = mne.io.RawArray(data, info, verbose=True)

#print(raw_intensity.get_data())

scalings = {'hbo': count, 'hbr': count}


raw_intensity.plot(n_channels=len(raw_intensity.ch_names), scalings=scalings,
                   title='Data from file',show=True, block=True)

if os.path.exists("results-mne.csv"):
  os.remove("results-mne.csv")
else:
  print("The file does not exist")
