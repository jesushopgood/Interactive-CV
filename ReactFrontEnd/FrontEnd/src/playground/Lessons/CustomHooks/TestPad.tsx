export default function TestPad(){
    let name = 'Peter';

    return (
        <input type="text" value={name} onChange={e=> name = e.target.value} />
    )
} 