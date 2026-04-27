import { useCallback, useState } from "react";
import { MedicineService } from "../services/MedicineService";
import { useNavigate } from "react-router-dom";

const AddMedicine = () => {
    const [medicineModel, setmedicineModel] = useState({ name: "", notes: "", price: 0.00, quantity: 0 });
    const medicineService = MedicineService.getInstance();
    const nav = useNavigate();

    const handleSubmit = useCallback((e: any) => {
        e.preventDefault();
        medicineService.addMedicine(medicineModel)
            .then((response: any) => {
                console.log("Medicine added successfully:", response);
                // Optionally, you can reset the form or navigate to another page
            })
            .catch((error: any) => {
                console.error("Error adding medicine:", error);
            });
    }, [medicineService, nav]);

    const handleCancel = useCallback(() => {
        // Reset the form or navigate back to the medicines list
        setmedicineModel({ name: "", notes: "", price: 0.00, quantity: 0 });
        nav("/medicines");
    }, [nav]);

    return (
        <div className="container">
            <form className="container mt-5" style={{ maxWidth: "400px" }} onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="name" className="form-label">Add New Medicine</label>
                    <input type="text" title="Enter Medicine Name" required={
                        true
                    } className="form-control" id="name" placeholder="Medicine Name" value={medicineModel.name} onChange={(e) => setmedicineModel({ ...medicineModel, name: e.target.value })} />
                </div>
                <div className="mb-3">
                    {/* <label htmlFor="notes" className="form-label">Notes</label> */}
                    <input type="text" multiple={true} title="Enter Notes"  className="form-control" id="notes" placeholder="Enter Notes" value={medicineModel.notes} onChange={(e) => setmedicineModel({ ...medicineModel, notes: e.target.value })} />
                </div>
                <div className="mb-3">
                    {/* <label htmlFor="price" className="form-label">Price</label> */}
                    <input type="number" title="Enter Price" required={
                        true
                    } className="form-control" id="price" placeholder="Price" value={medicineModel.price} onChange={(e) => setmedicineModel({ ...medicineModel, price: parseFloat(e.target.value) || 0 })} />
                </div>
                <div className="mb-3">
                    {/* <label htmlFor="quantity" className="form-label">Quantity</label> */}
                    <input type="number" title="Enter Quantity" required={
                        true
                    } className="form-control" id="quantity" placeholder="Quantity" value={medicineModel.quantity} onChange={(e) => setmedicineModel({ ...medicineModel, quantity: parseInt(e.target.value) || 0 })} />
                </div>
                <button type="submit" className="btn btn-primary">Add</button>
                <button type="button" className="btn btn-secondary ms-2" onClick={handleCancel}>
                    Cancel
                </button>
            </form>
        </div>)
}

export default AddMedicine;