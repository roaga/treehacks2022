# example of bayesian optimization for a 1d function from scratch
import math
from math import sin
from math import pi
from random import Random
import numpy as np
from numpy import arange
from numpy import vstack
from numpy import argmax
from numpy import asarray
from numpy.random import normal
from numpy.random import random
from scipy.stats import norm
from sklearn.gaussian_process import GaussianProcessRegressor
from warnings import catch_warnings
from warnings import simplefilter
from matplotlib import pyplot

# # objective function
# def objective(x, noise=0.1):
# 	noise = normal(loc=0, scale=noise)
# 	return (x**2 * sin(5 * pi * x)**6.0) + noise

# surrogate or approximation for the objective function
def surrogate(model, X):
	# catch any warning generated when making a prediction
	with catch_warnings():
		# ignore generated warnings
		simplefilter("ignore")
		return model.predict(X, return_std=True)

# probability of improvement acquisition function
def acquisition(X, Xsamples, model):
	# calculate the best surrogate score found so far
	yhat, _ = surrogate(model, X)
	best = max(yhat)
	# calculate mean and stdev via surrogate function
	mu, std = surrogate(model, Xsamples)
	mu = mu[:, 0]
	# calculate the probability of improvement
	probs = norm.cdf((mu - best) / (std+1E-9))
	return probs

# optimize the acquisition function
def opt_acquisition(X, y, model):
    # random search, generate random samples
    Xsamples = np.random.uniform(low=0, high=len(X), size=(len(X),)) # asarray(range(len(X))) # TODO: include floats, use constraints
    Xsamples = Xsamples.reshape(len(Xsamples), 1)
    # calculate the acquisition function for each sample
    scores = acquisition(X, Xsamples, model)
    # locate the index of the largest scores
    ix = argmax(scores) # TODO: we want to be minimizing dist from target reward/score instead
    return Xsamples[ix, 0]

# plot real observations vs surrogate function
def plot(X, y, model, target):
	# scatter plot of inputs and real objective function
    # pyplot.scatter(X, y)
    # line plot of surrogate function across domain
    Xsamples = asarray(arange(0, len(X), 0.01))
    Xsamples = Xsamples.reshape(len(Xsamples), 1)
    ysamples, _ = surrogate(model, Xsamples)
    maxX = Xsamples[find_nearest(ysamples, target)][0] # find closest to target instead of max
    # print(maxX)
    # maxX = Xsamples[argmax(ysamples)][0]
    # print(maxX)
    # pyplot.plot(Xsamples, ysamples)
    # show the plot
    # pyplot.show()
    return maxX

def find_nearest(array, value):
    array = np.asarray(array)
    idx = (np.abs(array - value)).argmin()
    return idx

def get_result(xpts, ypts, target):
    # for testing
    xpts = range(10)
    ypts = [random() * 20 for x in xpts]
    # sample the domain sparsely with noise
    X = asarray(xpts)
    Y = asarray(ypts)
    # reshape into rows and cols
    X = X.reshape(len(X), 1)
    y = Y.reshape(len(Y), 1)
    # define the model
    model = GaussianProcessRegressor()
    # fit the model
    model.fit(X, y)
    # plot before hand
    return plot(X, y, model, target)
    # perform the optimization process
    # for i in range(50):
    #     # select the next point to sample
    #     x = opt_acquisition(X, y, model)
    #     # sample the point
    #     val = min(X.flatten(), key=lambda k:abs(k - x))
    #     actual = min(Y, key=lambda k:abs(k - val))
    #     # summarize the finding
    #     est, _ = surrogate(model, [[x]])
    #     # print('>x=%.3f, f()=%3f, actual=%.3f' % (x, est, actual))
    #     # add the data to the dataset
    #     X = vstack((X, [[x]]))
    #     y = vstack((y, [[actual]]))
    #     # update the model
    #     model.fit(X, y)

    # # plot all samples and the final surrogate function
    # plot(X, y, model)
    # # best result
    # ix = argmax(y)
    # print('Best Result: x=%.3f, y=%.3f' % (X[ix], y[ix]))
    # return X[ix]

# for testing
print(get_result([], [], 10))