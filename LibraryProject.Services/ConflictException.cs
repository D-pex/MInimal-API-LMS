namespace LibraryProject.Services;

public sealed class ConflictException(string message) : Exception(message);