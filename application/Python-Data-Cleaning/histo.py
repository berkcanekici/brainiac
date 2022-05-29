import csv
import statistics
import numpy as np
import math


intervalNumber = 600
halfInterval = intervalNumber/2

def findHistogram(test, testNo):
    minValue = 3300
    maxValue = 4100
    meanValue = statistics.mean(test)
    delta = (maxValue-minValue) / intervalNumber
    
    # percent, interval, dataAmount
    histogram = [np.zeros(intervalNumber), [None] * intervalNumber, np.zeros(intervalNumber)]
    i = minValue
    index = 0
    
    # which one is %50
    while i < maxValue:
        if(abs(i- meanValue) < delta):
            break
        else:
            index = index +1
            i  = i + delta
    temp = index
    
    print("index: {}".format(index))
    if(index > halfInterval):
        print("here")
        divisonResult = 50 / (intervalNumber-index-1)
    else:
        divisonResult = 50 / index
    print(divisonResult)
    percentage = 50
    #print(index)
    while index >= 0:
        if(percentage < 0):
            percentage = 0
        histogram[0][index] = "{:.3f}".format(percentage)
        percentage = percentage - divisonResult
        #print("percentage {:.3f}".format( percentage))
        index = index - 1
    
    index = temp
    #print("index: {}".format(index))
    
    percentage = 50
    while index < intervalNumber:
        if(percentage > 100):
            percentage = 100
        histogram[0][index] = "{:.3f}".format(percentage)
        percentage = percentage + divisonResult
        #print("percentage: {:.3f}".format( percentage))
        index = index + 1
    
    
    i = minValue
    index = 0
    while i <= maxValue:
        count = 0
        if(index == intervalNumber):
            break
        for j in test:
            if(index == intervalNumber -1 ):
                if(j >=i and j <= math.ceil(i+delta)):
                    count = count + 1 
            else:
                if(j >=i and j < i+delta):
                    count = count + 1 
        histogram[2][index] = count
        histogram[1][index] = "{:.3f}-{:.3f}".format(i,i+delta)
        index = index +1 
        i = i + delta
        # percent, interval, dataAmount
    
    
    i =0 
    with open('test{}_histogram.csv'.format(testNo), 'w', newline='') as file:
        while i< intervalNumber:
            writer = csv.writer(file)
            data = []
            data.append(int(i+1))
            data.append("{:.3f}".format(histogram[0][i]))
            data.append(histogram[1][i])
            data.append(int(histogram[2][i]))
            writer.writerow(data)
            i +=1
    
    file.close()