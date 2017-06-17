# Product Repository
91大 TDD課程 #8 Day1 Homework

# 作業規範： #
* 作業可以只交 test case，如果你想挑戰 production code 十分歡迎，但請務必先寫好 test case
* 測試資料請勿使用迴圈產生，因為這資料只是「剛好」長這樣


# 需求： #
* 該11筆資料，如果要3筆成一組，取得 Cost 的總和的話，預期結果是 6, 15, 24, 21
* 該11筆資料，如果是4筆一組，取得 Revenue 總和的話，預期結果會是 50, 66, 60
* 筆數輸入負數或0，預期會拋 ArgumentException
* 尋找的欄位若不存在，預期會拋 ArgumentException
* 未來可能會新增其他欄位
* 希望這個API可以給其他 domain entity 用，例如 Employee
