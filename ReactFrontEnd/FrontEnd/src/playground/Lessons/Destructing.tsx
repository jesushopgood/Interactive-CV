const employee = {
  name: 'Peter',
  age: 53,
  height: 186,
  acheivements: ["Swimming Badge", "Marathon", "Clean Living"]
};

const { age, name } = employee;
const { height: heightInCm } = employee;

const { acheivements } = employee;
console.log(acheivements.length);

const fruits = ['apple', 'orange', 'pear', 'lime'];
const [greenFruit1,, greenFruit2] = fruits;

export { age, name, heightInCm, greenFruit1, greenFruit2 };


