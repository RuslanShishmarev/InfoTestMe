import * as React from 'react';
import { useState } from 'react';
import requestUrl from '../../../RequestUrls.json';
import { CourseBodyModel } from '../../interfaces/ICourse';
import words from '../../../LetterMessages.json';
import { selectImageBytesFromFile } from '../../js/services/UIServices';