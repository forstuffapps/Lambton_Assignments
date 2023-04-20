import numpy as np
import matplotlib.pyplot as plt


# Avinash Reddy Baddam , C0877290

plt.title("Avinash project")


x = np.random.randint(100, size=10)

#ax = plt.axes()

ax = plt.gca()
ax.set_facecolor("#221E22")

plt.plot(x, marker='o', color='#ECA72C')
plt.savefig('chart.png')
plt.show() 


