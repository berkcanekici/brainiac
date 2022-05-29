# -*- coding: utf-8 -*-
"""
Created on Fri May 27 22:51:37 2022

@author: ben
"""
import csv
import statistics
import numpy as np
import math


def findHistogram(test, testNo):
    minValue = min(test)
    maxValue = max(test)
    meanValue = statistics.mean(test)
    #print("mean of array: {}".format(statistics.mean(test)))
    #print("size of array: {}".format(len(test)))
    delta = (max(test)-min(test))/ 100
    
    # percent, interval, dataAmount
    histogram = [np.zeros(100), [None] * 100, np.zeros(100)]
    i = minValue
    index = 0
    
    while i < maxValue:
        if(abs(i- meanValue) < delta):
            break
        else:
            index = index +1
            i  = i + delta
    temp = index
    
    #print("index: {}".format(index))
    if(index >50):
        divisonResult = 50 / (100-index-1)
    else:
        divisonResult = 50 / index
        
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
    while index < 100:
        if(percentage > 100):
            percentage = 100
        histogram[0][index] = "{:.3f}".format(percentage)
        percentage = percentage + divisonResult
        #print("percentage: {:.3f}".format( percentage))
        index = index + 1
    
    
    i = minValue
    index = 0
    while i <= max(test):
        count = 0
        if(index == 100):
            break
        for j in test:
            if(index == 99):
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
        while i< 100:
            writer = csv.writer(file)
            data = []
            data.append(int(i+1))
            data.append("{:.3f}".format(histogram[0][i]))
            data.append(histogram[1][i])
            data.append(int(histogram[2][i]))
            writer.writerow(data)
            i +=1
    
    file.close()