import { useMemo, useState } from "react";

interface StockItem
{
    name: string;
    category: string;
}

export default function Memoization()
{
    const [sortOrder, setSortOrder] = useState("asc");
    const [filter, setFilter] = useState("");
    const [preFilter, setPreFilter] = useState("");

    const filteredAndSortedItems = useMemo(() => {
        
        const items:StockItem[] = 
        [
            { name: 'Sausages', category: 'Food' }, 
            { name: 'Eggs', category: 'Food'}, 
            { name: 'Tin Foil', category: 'Cooking' }, 
            { name: 'Pilchards', category: 'Food'}, 
            { name: 'Table', category: 'Furniture'},
            { name: 'Chair', category: 'Furniture' }, 
            { name: 'Bible', category: 'Book'}
        ];

        const result = items.filter(i => i.category.includes(filter) || i.name.includes(filter));

        result.sort((a, b) => {
            if (sortOrder === "asc") {
                return a.name.localeCompare(b.name);
            } else {
                return b.name.localeCompare(a.name);
            }
        });

        return result;
    
    }, [sortOrder, filter]); 

    const updateFilter = (value: string) => {
        setFilter(value);
    }

    const updatePreFilter= (value: string) => {
        if (value.length === 0) updateFilter(value);
        setPreFilter(value);
    } 

    return (
        
        <div className="container mt-4">(
            <h3>Sort/Filter Form</h3>
            
            <input type="text"
                    className="form-control mb-3"
                    placeholder="Filter items..."
                    value={preFilter}
                    onChange={(e) => updatePreFilter(e.target.value)}
            />
            <button className="my-2 btn btn-primary btn.sm" onClick={() => updateFilter(preFilter)}>Filter</button> 

            <p>{sortOrder}</p>
            <p><button onClick={() => sortOrder === 'asc' ? setSortOrder('desc') : setSortOrder('asc')}>Sort</button></p>

            {
                filteredAndSortedItems.length && 
                <ul className="list-group">
                    {
                        filteredAndSortedItems.map(fsi => (
                            <li className="list-item">{fsi.name} {fsi.category}</li>
                        ))
                    }
                </ul>
            }
        </div>
    )

}