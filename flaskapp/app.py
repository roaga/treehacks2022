from flask import Flask
from flask import request, jsonify
from flask.helpers import make_response
from bayes import get_result

app = Flask(__name__)

@app.route('/')
def home():
    return "insert easter egg here"

@app.route('/bayes', methods=["POST"])
def bayes():
    x = request.json['x']
    y = request.json['y']
    target = request.json['targetReward']
    min = request.json['min']
    max = request.json['max']
    return str(get_result(x, y, target, min, max))

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=105, debug=True)