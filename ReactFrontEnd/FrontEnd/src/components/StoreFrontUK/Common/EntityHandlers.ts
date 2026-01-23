export default interface EntityListProps<T extends string | number>
{
    onSelectEntity?: (entity: T) => void; 
}