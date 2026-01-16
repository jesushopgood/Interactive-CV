import useAdvancedFetch from "./useAdvancedFetch";

interface Post {
  id: number;
  title: string;
  body: string;
}


export default function AdvancedFetchClient(){
    const {data, error, loading} = useAdvancedFetch<Post[]>("https://jsonplaceholder.typicode.com/posts");

    return (
        <div>
            {loading && <p>Loading....</p>}
            {error && <p className="text-danger">{error.message}</p>}
            {data && (data as Post[]).slice(0,4).map((post,idx) => (
                <div key={idx} className="container p-2 border border-primary">
                    <p key={idx + 'A'}>{post.id}</p>
                    <p key={idx + 'B'}>{post.title}</p>
                    <p key={idx + 'C'}>{post.body}</p>
                </div>         
            ))}
        </div>
    )
    

}