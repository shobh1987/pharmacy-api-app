import { useEffect, useState } from "react";
import { MedicineService } from "../services/MedicineService";
import { useNavigate } from "react-router-dom";
import '../assets/css/Medicine.css';

const Medicines = () => {
  const medicineService = MedicineService.getInstance();
  const [medicines, setMedicines] = useState<any[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch medicines data from API
    const fetchMedicines = async () => {
      try {
        const data = await medicineService.getMedicines();
        console.log("Fetched medicines:", data);
        setMedicines(data);
      }
      catch (error) {
        console.error("Error fetching medicines:", error);
      }
    };
    fetchMedicines();
  }, []);

  const handleDelete = async(id: number) => {
    try {
      await medicineService.deleteMedicine(id);
      setMedicines(medicines.filter(medicine => medicine.id !== id));
    } catch (error) {
      console.error("Error deleting medicine:", error);
    }
  };

  return (
    <div className="container">
      <div className="d-flex flex-row align-items-center justify-content-between mt-4">
        <h3>Medicines</h3>
        <div>
          <button type="button" className="btn btn-primary btn-small mt-4 ms-5" onClick={() => navigate('/add-medicine')}>
            Add New Medicine
          </button>
        </div>
      </div>
      <table className="table">
        <thead>
          <tr>
            <th scope="col">#Id</th>
            <th scope="col">Name</th>
            <th scope="col">Quantity</th>
            <th scope="col">Price</th>
            <th scope="col">Expiry Date</th>
            <th scope="col">Actions</th>
          </tr>
        </thead>
        {medicines.length > 0 ? (
          <tbody>
            {medicines.map((medicine) => (
              <tr key={medicine.id}>
                <th scope="row">{medicine.id}</th>
                <td>{medicine.name}</td>
                <td>{medicine.quantity}</td>
                <td>{medicine.price}</td>
                <td>{medicine.expiryDate}</td>
                <td>
                  <button type="button" className="btn btn-outline-primary btn-small" onClick={(e) => {
                    e.stopPropagation();
                    navigate(`/medicines/${medicine.id}/edit`);
                  }}>
                    Edit
                  </button>
                   <button type="button" className="btn btn-outline-danger btn-small ms-2" onClick={(e) => {
                    e.stopPropagation();
                    handleDelete(medicine.id);
                  }}>
                    Delete
                  </button>
                </td>
              </tr>
            ))}

          </tbody>) : (
          <p>No medicines available.</p>
        )}
      </table>
    </div>
  )
}

export default Medicines;