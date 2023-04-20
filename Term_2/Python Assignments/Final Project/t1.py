import numpy as np
import matplotlib.pyplot as plt
#above are the libraries imported

# Avinash Baddam , C0877290 

# Set the title of the plot
plt.title("Avinash project")


plot1 = plt.subplot2grid((3, 3), (0, 0), colspan=2)
plot2 = plt.subplot2grid((3, 3), (0, 2), rowspan=3, colspan=2)
# Generate an array of 10 random integers between 0 and 99
x = np.random.randint(100, size=30)
y = np.random.randint(100, size=10)

# Get the current Axes instance and set the face color of the plot


# Plot the data with circular markers and a custom color
plot1.plot(x, marker='o', color='red')


plt.xlabel("Numbers")
plt.ylabel("Values")

ax = plt.gca()
ax.set_facecolor("#07020D")
plot2.plot(y, marker='.', color='#EAEAEA')
# Save the plot as a png file
plt.savefig('chart.png')

# Display the plot on the screen
plt.show()