interface QuestionAnswer
{
    Question: string;
    Answer: string;
}

const questionsAndAnswer: QuestionAnswer[] = [
    {Question: "What is the capital of Spain", Answer: "Madrid"},
    {Question: "What is the name of the King of Enland", Answer: "Charles"},
    {Question: "What is the name of Trump's son", Answer: "Barron"},
    {Question: "How many books are in the Bible", Answer: "66"},
    {Question: "Who are the current Premier League Champions", Answer: "Liverpool"},
    {Question: "Who played Bass in the Beatles", Answer: "Paul Mccartney"}
]; 

export{ type QuestionAnswer, questionsAndAnswer }