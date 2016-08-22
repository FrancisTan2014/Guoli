let isDone: boolean = false;
let decLiteral: number = 6;
let hexLiteral: number = 0xf00d;
let binaryLiteral: number = 0b1010;
let octalLiteral: number = 0o744;

let name1: string = 'FrancisTan';
let age: number = 26;
let sentence: string = `Hello, my name is ${name}. I'll be ${age + 1} years old next month.`;

let list: number[] = [1, 2, 3];

let array: Array<number> = [1, 2, 3];

let x: [string, number];
x = ['hello', 10];

console.log(x[0].substr(1));

x[3] = 'world';

console.log(x[5].toString());

enum Color { Red = 3, Green, Blue };
let c: Color = Color.Red;

let colorName: string = Color[2];
alert(colorName);

let notSure: any = 4;
notSure = 'maybe a string instead';
notSure = false;

// 声明一个void类型的变量没有什么大用，因为你只能为它赋予undefined和null
let unsuable: void = undefined || null;

// 类型断言（强制转换）
let someValue: any = 'this is a string';
let strLength = (<string>someValue).length;

// 解构
function f({a, b}: { a: '', b: 1}): void {

}

// 只读属性
interface Point {
    readonly x: number;
    readonly y: number;
}

interface SearchFunc {
    (src: string, sub: string): boolean;
    }

let mySearch: SearchFunc;
mySearch = function (src, sub) {
    let result = src.search(sub);
    if (result === -1) {
        return false;
    } else {
        return true;
    }
};

class MyClass {
    public state: any;
}