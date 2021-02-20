**Come back to add more stuff?**
- All checkboxes are in a list of controls
- Checkboxes have a tag, this is switched in BackupService to get the proper json by passing an empty type to ICosmosContext to get a list of objects
- This tag is used in the filename to create `{tag}{yyyyMMddTHHmmss}.json` in /ProgramData/
- If you need to add something as a precheck use `BackupService.Prechecks()`