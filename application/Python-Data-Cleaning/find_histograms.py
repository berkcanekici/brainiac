# -*- coding: utf-8 -*-
"""
Created on Tue May 24 14:29:23 2022

@author: ben
"""
#import matplotlib.pyplot as plt
import statistics
import numpy as np
import histo
def cleanTest(array, testArray):
    temp = []
    for i in array:
        cleanValues = []
        dev = statistics.stdev(i)
        mean = np.mean(i)
        if(dev < 1250):
            cleanValues.append(i)
        else:
            for j in i:
                if(abs(mean-j) > dev):
                    i.remove(j)
        #print(np.mean(i))
        temp.append(np.mean(i))
    #print(temp)
    """
    total = 0
    total = (temp[0] + temp[1]) / 2 * 70 / 100
    total += temp[2] * 20 / 100
    total += temp[3] * 10 / 100
    testArray.append(int(total))
    """
    testArray.append(np.mean(temp))
        #cleanValues.append(np.mean(i))
    #print(cleanValues)
    #print(np.mean(cleanValues))            
        
test1values = []
test2values = []
test4values = []
test5values = []

index = 0

while index< 300:
    fileString = "testData{}.txt".format(index+1)
    file = open(fileString,"r")
    test1 = [[],[],[],[]]
    test2=  [[],[],[],[]]
    test3 =  [[],[],[],[]]
    test4 =  [[],[],[],[]]
    test5 =  [[],[],[],[]]
    for line in file:
        values = []
        temp = line.split(";")
        if(len(temp) == 5):
            values.append(int(temp[1]))
            values.append(int(temp[2]))
            values.append(int(temp[3]))
            values.append(int(temp[4].rstrip("\n")))
            if(temp[0] == '1'):
                test1[0].append(values[0])
                test1[1].append(values[1])
                test1[2].append(values[2])
                test1[3].append(values[3])
            if(temp[0] == '2'):
                test2[0].append(values[0])
                test2[1].append(values[1])
                test2[2].append(values[2])
                test2[3].append(values[3])
            if(temp[0] == '3'):
                test3[0].append(values[0])
                test3[1].append(values[1])
                test3[2].append(values[2])
                test3[3].append(values[3])
            if(temp[0] == '4'):
                test4[0].append(values[0])
                test4[1].append(values[1])
                test4[2].append(values[2])
                test4[3].append(values[3])
            if(temp[0] == '5'):
                test5[0].append(values[0])
                test5[1].append(values[1])
                test5[2].append(values[2])
                test5[3].append(values[3])

    cleanTest(test1,test1values)    
    for i in test3:
        test2.append(i)
    cleanTest(test2,test2values)        
    cleanTest(test4,test4values)        
    cleanTest(test5,test5values)        
    index +=1



histo.findHistogram(test1values, 1)
histo.findHistogram(test2values, 2)
histo.findHistogram(test4values, 4)
histo.findHistogram(test5values, 5)
print("Histograms are created")