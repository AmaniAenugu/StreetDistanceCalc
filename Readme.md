# Street Management

The project is used to Add streets with their start and end co-ordinates

## Getting Started

This is the API project which has mainly three endpoints exposed. Swagger UI is used for testing the endpoints

## Running the tests

Test1:

Post the below street data to baseURL/street HTTPPost verb

{
  "name": "Street1",
  "start": {
    "x": 0,
    "y": 0
  },
  "end": {
    "x": 5,
    "y": 10
  }
}

{
  "name": "Street2",
  "start": {
    "x": 5,
    "y": 10
  },
  "end": {
    "x": 15,
    "y": 25
  }
}

The data should be saved sucessfully.

Input:

Invoke /closest HTTPGET Verb with x and y cooridates
x=5
y=5

Output:
[
  "Street2"
]


Test2:

Post the below street data to baseURL/street HTTPPost verb

{
  "name": "Street3",
  "start": {
    "x": 5,
    "y": 10
  },
  "end": {
    "x": 15,
    "y": 25
  }
}

The data should be saved sucessfully.

Input:

Invoke /closest HTTPGET Verb with x and y cooridates
x=5
y=5

Output:
[
  "Street2",
  "Street3"
]

