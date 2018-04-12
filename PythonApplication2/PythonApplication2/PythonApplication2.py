import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from scipy.stats import expon


#df = pd.read_csv("PastHires.csv")
#print(df.columns)


#count = df['Years Experience']#.value_counts().sort_values(ascending = False)
#count.plot(kind='bar')
#print(count)
#plt.show()
#print(np.mean(count))
#plt.hist(count)
#plt.show()

#incoms = np.random.uniform(-10,10,10000)
#plt.hist(incoms)
vals = np.random.normal(0,0.5,10000)
plt.hist(vals,50)
print(np.percentile(vals,99.99999))
plt.xlabel('x')
plt.ylabel('y')
plt.legend(['normal','other normal'], loc = 1)
plt.show()
