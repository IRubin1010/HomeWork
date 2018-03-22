import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

df = pd.read_csv("PastHires.csv")
print(df.columns)

count = df['Years Experience']#.value_counts().sort_values(ascending = False)
count.plot(kind='bar')
print(count)
plt.show()
#print(np.mean(count))
#plt.hist(count)
#plt.show()
