interface User {
    name: string;
    userName: string;
    role: string;
    lastLoggedInAt: string;
    sessionKey: string;
}

const users:User[] = [
    {name: 'David Tylor', userName: 'davift001', role: "admin", lastLoggedInAt: "12:23", sessionKey: 'ABCX123'},
    {name: 'Nigel Smith', userName: 'nigels999', role: "user", lastLoggedInAt: "05:30", sessionKey: 'DEFX9091'},
    {name: 'Leslie Allen', userName: 'lesliea02', role: "user", lastLoggedInAt: "07:11", sessionKey: 'FDG1091'},
    {name: 'Sampson Smith', userName: 'samps001', role: "operator", lastLoggedInAt: "09:09", sessionKey: 'CAR0012'},
    {name: 'Carol Marches', userName: 'carol902', role: "admin", lastLoggedInAt: "12:59", sessionKey: 'ABC10090'},
]

export { type User, users }



