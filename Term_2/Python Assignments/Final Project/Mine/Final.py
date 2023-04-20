import matplotlib.pyplot as plt
import numpy as np


# Full Name : Vishal Reddy Guda
# C_Number : c0869346

# Adding the title to the Graph
plt.title("C0869346_Vishal_Reddy")


# Graph_1 Line Graph
x = np.random.choice(100, size=50)
# making subplots... Subplot_1
plt.subplot(2,2,1)
# stating a label
plt.ylabel("Values range=100")
plt.plot(x, color='#64E9EE')
# adding the background color for the Graph_1
ax = plt.gca()
ax.set_facecolor("#001011")


# Graph_2 Scatter Graph
x=np.random.randint(400,size=20)
y = np.random.randint(10, size=20)
# Sub plot 2
plt.subplot(2,2,2)
plt.scatter(x,y, color='#EAEAEA')
# adding the background color for the Graph_2
ax = plt.gca()
ax.set_facecolor("#050404")



# Graph_3 Bar Graph
x=np.array(['1','2','3','4','5','6','7','8','9','10','11','12'])
y = np.random.randint(10000, size=12)
# Sub Plot 3
plt.subplot(2,2,3)
plt.ylabel("Stocks")
plt.bar(x,y, color='#D64933')
# adding the background color for the Graph_3
ax = plt.gca()
ax.set_facecolor("#2B303A")


# Graph_4 Pie Graph
y = np.array([32, 12, 14, 23, 19 ])
mylabels = ["Dev Team", "QA", "Design", "CSM", "Sales"]
Top=(0.3,0,0,0,0)
# Sub Plot 4
plt.subplot(2,2,4)
plt.pie(y, labels = mylabels, autopct='%.0f', explode=Top)


# saving the image to local
plt.savefig('C0869346_Vishal.png')

# final rendering of the graph
plt.show()