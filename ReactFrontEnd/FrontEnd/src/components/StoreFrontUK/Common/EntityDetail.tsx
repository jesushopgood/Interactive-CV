import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useEffect, useRef, useState, type JSX } from "react";
import ToggledReadOnlyInput from "./ReadOnlyInput";
import { TabContainer } from "../../Common/Layout/TabContainer";
import { StringHelper } from "../../CustomHooks/Libraries/StringHelper";

interface EntityField<T>
{
    id: string;
    label: string;
    fieldName: string;
}

export interface CompositeControl {
  component: (data: { data: unknown }) => JSX.Element | undefined;
  path: string;
  label: string
}


export interface EntityDetailsProps<T>
{
  entityId?: string;
  emptyEntity: T;
  backToResults?: () => void;
  queryKey: (id?: string) => unknown[];
  loadEntity: (id: string) => Promise<T>;
  createEntity: (entity: T) => Promise<unknown>;
  updateEntity: (entity: T) => Promise<unknown>;
  onLoaded?: (title: string) => void;
  getTitle: (entity: T) => string;
  fields: Array<EntityField<T>>;
  compositeControls: CompositeControl[]; 
};

export function EntityDetail<T>(props: EntityDetailsProps<T>) {
    const {
        entityId,
        emptyEntity,
        queryKey,
        loadEntity,
        createEntity,
        updateEntity,
        onLoaded,
        getTitle,
        backToResults,
        fields,
        compositeControls = []
    } = props;

    const isNew = entityId === undefined;

    const [isEditOn, setIsEditOn] = useState(isNew);
    const [formData, setFormData] = useState<T>(emptyEntity);
    const stringHelperRef = useRef<StringHelper | null>(null);
    stringHelperRef.current = new StringHelper();

    const queryClient = useQueryClient();

    const { data, isLoading, error } = useQuery<T>({
        queryKey: queryKey(entityId),
        queryFn: () => loadEntity(entityId!),
        enabled: !isNew
    });

    const updateCustomerMutation = useMutation({
        mutationFn: updateEntity,
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: queryKey(entityId) });
        }
    });

    const createCustomerMutation = useMutation({
        mutationFn: createEntity,
        onSuccess: () => {
            queryClient.invalidateQueries({queryKey: queryKey(entityId)});
        }
    });

    const updateFormData = (localFormData: T) => {
        console.log(localFormData);
        setFormData(localFormData);
    }

    const handleSaveClick = () => {
        setIsEditOn(prev => {
            const result = !prev;
            if (!result){
                if (isNew) createCustomerMutation.mutate(formData);
                else updateCustomerMutation.mutate(formData);
            }   
            return result;
        });
    };


    // We notify when we've loaded so we can pass this up to the parent tab to give the tab 
    // the name of the entity
    useEffect(() => {
        if(data) {
            onLoaded?.(getTitle(data));
            setFormData(data);
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [data])


    if (isLoading) return <p>Loading...</p>;
    if (error) return <p>Something went wrong {error.message}</p>;

    return (
        <div className="container-fluid">
            <div className="d-flex justify-content-between mb-4">
                <button className={`btn ${isEditOn ? "btn-outline-danger" : "btn-outline-primary"} m-0`} 
                                            onClick={handleSaveClick}>{isEditOn || isNew ? "Save": "Edit"}</button>
                <button className="btn  btn-outline-primary m-0" onClick={backToResults}>Back To Results</button>
            </div>
            <table className="table table-borderless entity-table">
                <tbody>
                    {
                        fields.map((field,idx) => 
                            <tr key={idx}>
                                <td><label className="form-label" htmlFor={field.id}>{field.label}</label></td>
                                <td><ToggledReadOnlyInput<T> 
                                    id={field.id} 
                                    isReadOnly={!isEditOn} 
                                    value={stringHelperRef.current?.getByPath(formData, field.fieldName)}
                                    onEdit={(data:T) => updateFormData(data)}
                                    formData={formData}
                                    fieldName={field.fieldName as string} /> 
                                </td>
                            </tr>
                    )}
                </tbody>
            </table>
            
            
            <TabContainer tabs={ compositeControls.map((cf, idx) => {
                const Component= cf.component;
                // eslint-disable-next-line @typescript-eslint/no-explicit-any
                const safePath = (formData as any)[cf.path];
                
                return { id: cf.label, 
                            label: cf.label, 
                            content: <Component key={idx} data={safePath}  />
                };
            })}
            />
        </div>
    )
}

