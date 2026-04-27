import axisosInstance from "./APIServices";

export class MedicineService {

    private static instance: MedicineService;

    private constructor() { }

    static getInstance(): MedicineService {
        if (!MedicineService.instance) {
            MedicineService.instance = new MedicineService();
        }
        return MedicineService.instance;
    }

    async getMedicines() {
        try {
            const response = await axisosInstance.get("medicine");
            console.log("API response for medicines:", response);
            return response.data;
        } catch (error) {
            console.error("Error fetching medicines:", error);
            throw error;
        }
    }

    async addMedicine(medicineModel: any) {
        try {
            const response = await axisosInstance.post("medicine", medicineModel);
            console.log("API response for adding medicine:", response);
            return response.data;
        } catch (error) {
            console.error("Error adding medicine:", error);
            throw error;
        }
    }

    async deleteMedicine(id: number) {
        try {
            const response = await axisosInstance.delete(`medicine?medicineId=${id}`);
            console.log("API response for deleting medicine:", response);
            return response.data;
        } catch (error) {
            console.error("Error deleting medicine:", error);
            throw error;
        }
    }
}