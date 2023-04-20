import numpy as np
import matplotlib.pyplot as plt
#above are the libraries imported

# Avinash Baddam , C0877290 

# Set the title of the plot
plt.title("Avinash project")

# Generate an array of 10 random integers between 0 and 99
x = np.random.randint(100, size=10)

# Get the current Axes instance and set the face color of the plot
ax = plt.gca()
ax.set_facecolor("#221E22")

# Plot the data with circular markers and a custom color
plt.plot(x, marker='o', color='#ECA72C')

plt.xlabel("Numbers")
plt.ylabel("Values")

# Save the plot as a png file
plt.savefig('chart.png')

# Display the plot on the screen
plt.show()