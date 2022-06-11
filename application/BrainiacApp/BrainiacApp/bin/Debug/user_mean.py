import statistics
import numpy as np
import sys
import os

def intervalFinder(testval1,testval2,testval4,testval5):
    if os.path.exists("results.csv"):
        os.remove("results.csv")
    
    file = open('results.csv','w',777) #result dosyası açılıyor.
    testNo = 0
    for q in range (4):
        """
        q değerine göre dosya ismini bulduk
        dosyayı okuduk
        her bir sütunu ayrı bir arraye attık
        
        """
        if (q < 2):
            testNo = q + 1
        else:
            testNo = q + 2
        
        toCsv =open('test{}_histogram.csv'.format(testNo),'r')
    
        ch1 = np.array([])
        ch2 = np.array([])
        ch3 = np.array([])
        ch4 = np.array([])

        
        while True:
    
            line = toCsv.readline()
         
            # if line is empty EOF is reached
            if not line:
                break
            if(line!='\n'): #skip the just empty line from file.
                a,b,c,d=line.split(",")
                ch1 = np.append(ch1,a )
                ch2 = np.append(ch2,b )
                ch3 = np.append(ch3,c )
                ch4 = np.append(ch4,d )
        toCsv.close()
        """
        test valuelarına göre 
        histogram dosyasından intervalları bulduk
        aralığa uygun yüzdeyi de kaydettik
        interval ve yüzde değerlini de results.csv dosyasına yazdık
        results.csv dosya formatı:
        uyan %'lik dilim ve interval1-interval2 aralığı
        Lütfen kodlarınıza bu şekilde yorum satırı eklemeyi unutmayın.
        """
        for i in range(len(ch3[:])):
            interval = np.take(ch3, i)
            interval1, interval2 = interval.split("-")
            testval = []
            if (testNo == 1):
                testval = test1values
            if (testNo == 2):
                testval = test2values
            if (testNo == 4):
                testval = test4values
            if (testNo == 5):
                testval = test5values
            test1floatval = [float(j) for j in testval]
            floatinterval1 = float(interval1)
            floatinterval2 = float(interval2)
            if test1floatval[0] >= floatinterval1 and test1floatval[0] < floatinterval2:
                print(np.take(ch2,i))
                print(interval1,interval2)
                file.write(str(np.take(ch2,i)))
                file.write(",")
                file.write(str(interval1))
                file.write("-")
                file.write(str(interval2))
                file.write("\n")
    file.close()
        





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


fileString = sys.argv[1]
print(fileString)
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

intervalFinder(test1values, test2values, test4values, test5values)
        
    
    
    
        
