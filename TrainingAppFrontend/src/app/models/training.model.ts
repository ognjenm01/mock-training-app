import { TrainingType } from "./training-type.model";

export interface Training {
   id: number,
   typeId: number,
   type: TrainingType,
   duration: string,
   difficulty: number,
   tiredness: number,
   caloriesBurned: number,
   note: string,
   created: Date,
   userId: number
}