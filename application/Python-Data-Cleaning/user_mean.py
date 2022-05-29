import statistics
import statistics
import numpy as np
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
        temp.append(np.mean(i))
    testArray.append(np.mean(temp))
        
test1values = []
test2values = []
test4values = []
test5values = []

index = 0


fileString = "rrrr"
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

print("Test 1 Results: {}, Test 2-3 Results: {}, Test 4 Results: {}, Test 5 Results: {}", test1values, test2values, test4values, test5values)