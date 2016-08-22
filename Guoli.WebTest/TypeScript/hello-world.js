var isDone = false;
var decLiteral = 6;
var hexLiteral = 0xf00d;
var binaryLiteral = 10;
var octalLiteral = 484;
var name1 = 'FrancisTan';
var age = 26;
var sentence = "Hello, my name is " + name + ". I'll be " + (age + 1) + " years old next month.";
var list = [1, 2, 3];
var array = [1, 2, 3];
var x;
x = ['hello', 10];
console.log(x[0].substr(1));
x[3] = 'world';
console.log(x[5].toString());
var Color;
(function (Color) {
    Color[Color["Red"] = 3] = "Red";
    Color[Color["Green"] = 4] = "Green";
    Color[Color["Blue"] = 5] = "Blue";
})(Color || (Color = {}));
;
var c = Color.Red;
var colorName = Color[2];
alert(colorName);
var notSure = 4;
notSure = 'maybe a string instead';
notSure = false;
// 声明一个void类型的变量没有什么大用，因为你只能为它赋予undefined和null
var unsuable = undefined || null;
// 类型断言（强制转换）
var someValue = 'this is a string';
var strLength = someValue.length;
// 解构
function f(_a) {
    var a = _a.a, b = _a.b;
}
readonly;
x: number;
readonly;
y: number;
var mySearch;
mySearch = function (src, sub) {
    var result = src.search(sub);
    if (result === -1) {
        return false;
    }
    else {
        return true;
    }
};
var MyClass = (function () {
    function MyClass() {
    }
    return MyClass;
}());
