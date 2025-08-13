using SQLite;
using BuddyConnect.DatabaseModel;
using System.Diagnostics;
using BuddyConnect.Functions;


namespace BuddyConnect.Controllers {

    /// <summary>
    /// Table Controlers
    /// LanguageList 
    /// </summary>
    public static class NoteListController {

        public static async Task<List<NoteList>> GetNoteList() {
            return await App.appSetting.Database.Table<NoteList>().ToListAsync();
        }


        public static async Task<NoteList> GetNoteListListById(int id) {
            return await App.appSetting.Database.Table<NoteList>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }


        public static async Task<int> InsertOrUpdateNoteList(NoteList item) {
            try {
                if (item.Id != 0) {
                    return await App.appSetting.Database.UpdateAsync(item);
                } else { return await App.appSetting.Database.InsertAsync(item); }
            } catch (Exception ex) {
                await DetectedErrorListController.SaveDetectedErrorList(new DetectedErrorList() { Message = SystemFunctions.GetSystemErrMessage(ex) });
            }
            return 0;
        }


        public static async Task<int> SaveNoteList(NoteList item) {
            try {
                return await App.appSetting.Database.InsertAsync(item);
            } catch (Exception ex) {
                await DetectedErrorListController.SaveDetectedErrorList(new DetectedErrorList() { Message = SystemFunctions.GetSystemErrMessage(ex) });
            }
            return 0;
        }


        public static async Task<int> SaveNoteListRange(List<NoteList> item) {
            try { 
                return await App.appSetting.Database.InsertAllAsync(item);
            } catch (Exception ex) {
                await DetectedErrorListController.SaveDetectedErrorList(new DetectedErrorList() { Message = SystemFunctions.GetSystemErrMessage(ex) });
                
            }
            return 0;
        }

        public static async Task<int> DeleteNoteItemAsync(NoteList item) {
            try {
                return await App.appSetting.Database.DeleteAsync(item);
            } catch (Exception ex) {
                await DetectedErrorListController.SaveDetectedErrorList(new DetectedErrorList() { Message = SystemFunctions.GetSystemErrMessage(ex) });
                
            }
            return 0;
        }


    }
}